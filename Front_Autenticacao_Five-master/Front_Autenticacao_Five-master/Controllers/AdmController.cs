using FiveMotors.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace FiveMotors.Controllers
{
    public class AdmController : Controller
    {
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            using var client = new HttpClient();
            var json = await client.GetStringAsync("http://localhost:5206/api/Veiculos");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var veiculos = JsonSerializer.Deserialize<List<Veiculo>>(json, options);

            if (veiculos == null)
                veiculos = new List<Veiculo>();

            return View(veiculos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Veiculo veiculo)
        {
            using var client = new HttpClient();
            var json = JsonSerializer.Serialize(veiculo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:5206/api/Veiculos", content);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            using var client = new HttpClient();
            var json = await client.GetStringAsync($"http://localhost:5206/api/Veiculos/{id}");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var veiculo = JsonSerializer.Deserialize<Veiculo>(json, options);
            return View(veiculo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Veiculo veiculo)
        {
            using var client = new HttpClient();
            var json = JsonSerializer.Serialize(veiculo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PutAsync($"http://localhost:5206/api/Veiculos/{veiculo.VeiculosId}", content);
            return RedirectToAction("Index");
        }



        
        public async Task<IActionResult> Delete(Guid id)
        {
            using var client = new HttpClient();
            var json = await client.GetStringAsync($"http://localhost:5206/api/Veiculos/{id}");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var veiculo = JsonSerializer.Deserialize<Veiculo>(json, options);
            if (veiculo == null) return NotFound();
            return View(veiculo);
        }

        
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"http://localhost:5206/api/Veiculos/{id}");
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }


        /* Area de recebimento de falas do cliente */

        public async Task<IActionResult> Mensagens()
        {
            using var client = new HttpClient();
            var json = await client.GetStringAsync("http://localhost:5206/api/FaleComVendedor");
            var mensagens = JsonSerializer.Deserialize<List<FaleComVendedor>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<FaleComVendedor>();
            return View(mensagens);
        }

        [HttpPost]
        public async Task<IActionResult> EnviarMensagem(FaleComVendedor input)
        {
            using var client = new HttpClient();
            var json = JsonSerializer.Serialize(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await client.PostAsync("http://localhost:5206/api/FaleComVendedor", content);

            return Ok(); 
        }


        public async Task<IActionResult> DetalhesMensagem(Guid id)
        {
            using var client = new HttpClient();
            var json = await client.GetStringAsync($"http://localhost:5206/api/FaleComVendedor/{id}");
            var mensagem = JsonSerializer.Deserialize<FaleComVendedor>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (mensagem == null) return NotFound();
            return View(mensagem);
        }

        [HttpPost, ActionName("DeletarMensagem")]
        public async Task<IActionResult> DeletarMensagemConfirmed(Guid id)
        {
            using var client = new HttpClient();
            await client.DeleteAsync($"http://localhost:5206/api/FaleComVendedor/{id}");
            return RedirectToAction("Mensagens");
        }
    }
}
