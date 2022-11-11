using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Usuario
{
    public int id { get; set; }
    public string nome { get; set; }
    public string tipoUsuario { get; set; }
    public string email { get; set; }
    public string senha { get; set; }
    public string confirmaSenha { get; set; }
}
public class UsuarioCaixa
{
    public int id { get; set; }
    public string emailCaixa { get; set; }
}

public class UsuarioGerente
{
    public int id { get; set; }
    public string emailGerente { get; set; }
}
