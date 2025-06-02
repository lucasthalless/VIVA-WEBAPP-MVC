using Microsoft.AspNetCore.Mvc;
using MOTTHRU.API.Application.Interfaces;

namespace VIVA_WEBAPP_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioApplicationService _usuarioApplicationService;

        public UsuarioController(IUsuarioApplicationService usuarioApplicationService)
        {
            _usuarioApplicationService = usuarioApplicationService;
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
