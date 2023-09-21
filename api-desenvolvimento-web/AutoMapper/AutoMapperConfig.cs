using api_desenvolvimento_web.DTO;
using api_desenvolvimento_web.Models;
using AutoMapper;
using Projeto.Business.Models;

namespace api_desenvolvimento_web.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        { 
            CreateMap<CriarUsuarioModel, CriarUsuarioDTO>().ReverseMap();
            CreateMap<LoginModel, LoginDTO>().ReverseMap();
            CreateMap<ResetarSenhaModel, ResetarSenhaDTO>().ReverseMap();
            CreateMap<Paciente, CriarPacienteDTO>().ReverseMap();
            CreateMap<Paciente, AtualizarPacienteDTO>().ReverseMap();
            CreateMap<Endereco, CriarEndereco>().ReverseMap();
            CreateMap<Endereco, AtualizarEnderecoDTO>().ReverseMap();
            CreateMap<Profissional, CriarProfissionalDTO>().ReverseMap();
            CreateMap<Profissional, AtualizarProfissionalDTO>().ReverseMap();
        }
    }
}
