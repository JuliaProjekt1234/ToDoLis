using MediatR;
using ToDoList.Commands.Command;
using ToDoList.Repositories;

namespace ToDoList.Commands.CommanHandler;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    public LoginUserCommandHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUser(request.UserDto.Name, request.UserDto.Password);
        if (user == null)
            throw new Exception("");

        return Base.JwtTokenGenerator.GenerateJwtToken(user);
    }
}
