namespace WinFormsWenSoftAdmin.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? UsuarioNombre { get; set; }
        public string? Clave { get; set; }
        public int IdEmpresa { get; set; }
        public string EmpresaNombre { get; set; } = "";
        public int IdRol { get; set; }
        public string? RolNombre { get; set; }
    }
}
