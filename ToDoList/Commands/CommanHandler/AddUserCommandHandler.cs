using MediatR;
using ToDoList.Commands.Command;
using ToDoList.Models;
using ToDoList.Repositories;
using ToDoList.Services;

namespace ToDoList.Commands.CommanHandler
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async System.Threading.Tasks.Task Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var userToSave = request.User;
            if (userToSave.Password != userToSave.ConfirmedPassword)
            {
                throw new Exception("");
            }
            await _userRepository.AddUser(userToSave.Name, userToSave.Password);
        }
    }
}
