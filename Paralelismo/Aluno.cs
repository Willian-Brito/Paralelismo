namespace Paralelismo;

public class Aluno
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public static IEnumerable<Aluno> GetAlunos()
    {
        var alunos = new List<Aluno> {
            new Aluno{Nome="Paulo", Idade=45},
            new Aluno{Nome="Carina", Idade=34},
            new Aluno{Nome="Danilo", Idade=28},
            new Aluno{Nome="Carlos", Idade=23},
            new Aluno{Nome="Maria", Idade=38},
            new Aluno{Nome="Catia", Idade=47},
            new Aluno{Nome="Marta", Idade=52},
            new Aluno{Nome="Clarisse", Idade=62},
            new Aluno{Nome="Claudio", Idade=23},
            new Aluno{Nome="Milena", Idade=21}
        };

        return alunos;
    }
}
