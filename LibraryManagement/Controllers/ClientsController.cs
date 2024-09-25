using LibraryManagement.Service.Command.Client.Add;
using LibraryManagement.Service.Command.Client.Delete;
using LibraryManagement.Service.Command.Client.Update;
using LibraryManagement.Service.Query.Client;
using LibraryManagement.Storage.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ILibraryRepository _libraryRepository;

        public ClientsController(ILibraryRepository repository)
        {
            _libraryRepository = repository;
        }

        public IActionResult Index()
        {
            var handler = new GetAllClientsQueryHandler(_libraryRepository);
            var query = new GetAllClientsQuery();
            var clients = handler.Handle(query);
            return View(clients);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddClientCommand command)
        {
            var handler = new AddClientCommandHandler(_libraryRepository);
            var result = handler.Handle(command);

            if (result.IsFailure)
            {
                return View(command);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var client = _libraryRepository.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }

            var command = new UpdateClientCommand
            {
                ClientId = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                Email = client.Email
            };

            return View(command);
        }

        [HttpPost]
        public IActionResult Edit(UpdateClientCommand command)
        {
            var handler = new UpdateClientCommandHandler(_libraryRepository);
            var result = handler.Handle(command);

            if (result.IsFailure)
            {
                return View(command);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(DeleteClientCommand command)
        {
            var handler = new DeleteClientCommandHandler(_libraryRepository);
            var result = handler.Handle(command);

            return RedirectToAction("Index");
        }
    }
}
