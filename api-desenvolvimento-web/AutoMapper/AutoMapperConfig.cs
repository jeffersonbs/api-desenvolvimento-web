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
            CreateMap<Endereco, CriarEnderecoDTO>().ReverseMap();
            CreateMap<Endereco, AtualizarEnderecoDTO>().ReverseMap();
            CreateMap<Profissional, CriarProfissionalDTO>().ReverseMap();
            CreateMap<Profissional, AtualizarProfissionalDTO>().ReverseMap();
            CreateMap<Atendimento, CriarAtendimentoDTO>().ReverseMap();
            CreateMap<Atendimento, AtualizarAtendimentoDTO>().ReverseMap();
            CreateMap<CID, CriarCID>().ReverseMap();
            CreateMap<CID, AtualizarCIDDTO>().ReverseMap();
            CreateMap<Diagnostico, CriarDiagnosticoDTO>().ReverseMap();
            CreateMap<Diagnostico, AtualizarDiagnosticoDTO>().ReverseMap();
        }
    }
}
