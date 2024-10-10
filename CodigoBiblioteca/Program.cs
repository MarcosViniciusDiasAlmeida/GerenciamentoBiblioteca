using System;
using System.Collections.Generic;

class Program
{
    static List<Livro> biblioteca = new List<Livro>();
    static Usuario usuarioLogado;

    static void Main(string[] args)
    {
        InicializarDados();
        MenuPrincipal();
    }

    static void InicializarDados()
    {
        biblioteca.Add(new Livro("Dom Casmurro", "Machado de Assis", 5));
        biblioteca.Add(new Livro("1984", "George Orwell", 3));
        biblioteca.Add(new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", 2));
    }

    static void MenuPrincipal()
    {
        while (true)
        {
            Console.WriteLine("\n1. Fazer login");
            Console.WriteLine("2. Sair");
            var opcao = Console.ReadLine();

            if (opcao == "1") FazerLogin();
            else if (opcao == "2") break;
        }
    }

    static void FazerLogin()
    {
        Console.Write("Usuário: ");
        var usuario = Console.ReadLine();
        Console.Write("Senha: ");
        var senha = Console.ReadLine();

        if (usuario == "admin" && senha == "admin123")
        {
            usuarioLogado = new Usuario(usuario);
            MenuUsuario();
        }
        else
        {
            Console.WriteLine("Usuário ou senha inválidos!");
        }
    }

    static void MenuUsuario()
    {
        while (true)
        {
            Console.WriteLine("\n1. Cadastrar livro");
            Console.WriteLine("2. Consultar catálogo");
            Console.WriteLine("3. Emprestar livro");
            Console.WriteLine("4. Devolver livro");
            Console.WriteLine("5. Sair");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": CadastrarLivro(); break;
                case "2": ConsultarCatalogo(); break;
                case "3": EmprestarLivro(); break;
                case "4": DevolverLivro(); break;
                case "5": return;
                default: Console.WriteLine("Opção inválida! Tente novamente."); break;
            }
        }
    }

    static void CadastrarLivro()
    {
        Console.Write("Título: ");
        var titulo = Console.ReadLine();
        Console.Write("Autor: ");
        var autor = Console.ReadLine();
        Console.Write("Quantidade: ");
        int quantidade = int.Parse(Console.ReadLine());

        biblioteca.Add(new Livro(titulo, autor, quantidade));
        Console.WriteLine("Livro cadastrado com sucesso!");
    }

    static void ConsultarCatalogo()
    {
        Console.WriteLine("\n--- Catálogo de Livros ---");
        foreach (var livro in biblioteca)
        {
            Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, Disponível: {livro.Quantidade}");
        }
    }

    static void EmprestarLivro()
    {
        if (usuarioLogado.LivrosEmprestados.Count >= 3)
        {
            Console.WriteLine("Limite de 3 livros já atingido.");
            return;
        }

        Console.Write("Título do livro: ");
        var titulo = Console.ReadLine();
        var livro = biblioteca.Find(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (livro != null && livro.Quantidade > 0)
        {
            livro.Quantidade--;
            usuarioLogado.LivrosEmprestados.Add(livro);
            Console.WriteLine($"Livro '{livro.Titulo}' emprestado com sucesso!");
        }
        else
        {
            Console.WriteLine("Livro não disponível.");
        }
    }

    static void DevolverLivro()
    {
        Console.Write("Título do livro: ");
        var titulo = Console.ReadLine();
        var livro = usuarioLogado.LivrosEmprestados.Find(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (livro != null)
        {
            livro.Quantidade++;
            usuarioLogado.LivrosEmprestados.Remove(livro);
            Console.WriteLine($"Livro '{livro.Titulo}' devolvido com sucesso!");
        }
        else
        {
            Console.WriteLine("Você não possui este livro emprestado.");
        }
    }
}

class Livro
{
    public string Titulo { get; }
    public string Autor { get; }
    public int Quantidade { get; set; }

    public Livro(string titulo, string autor, int quantidade)
    {
        Titulo = titulo;
        Autor = autor;
        Quantidade = quantidade;
    }
}

class Usuario
{
    public string Nome { get; }
    public List<Livro> LivrosEmprestados { get; } = new List<Livro>();

    public Usuario(string nome)
    {
        Nome = nome;
    }
}
