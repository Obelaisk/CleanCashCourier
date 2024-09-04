using ApiClases_20270722_Proyecto.Modelos.Clientes;

namespace ApiClases_20270722_Proyecto.Profiles;

public class ClientePerfil:Profile {

    public ClientePerfil(){
        CreateMap<Cliente, ClienteBaseDto>()
                    .ForMember(dest => dest.NombrePais, opt => opt.MapFrom(src => src.Pais.Nombre));  // Mapea el nombre del país
        CreateMap<ClienteBaseDto, Cliente>();

        // Mapeo de Cliente a ClienteGetDto y viceversa
        CreateMap<Cliente, ClienteGetDto>()
            .IncludeBase<Cliente, ClienteBaseDto>(); 

        // Mapeo de ClientePutDto a Cliente
        CreateMap<ClientePutDto, Cliente>()
            .IncludeBase<ClienteBaseDto, Cliente>();

        // Mapeo de ClienteDeleteDto a Cliente
        CreateMap<ClienteDeleteDto, Cliente>()
            .IncludeBase<ClienteBaseDto, Cliente>();

        CreateMap<ClienteRegistro, Cliente>().
            IncludeBase<ClienteBaseDto, Cliente>();


        CreateMap<Pais, PaisDto>().ReverseMap();
    }
}
