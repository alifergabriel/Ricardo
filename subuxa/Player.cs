using FFImageLoading.Maui;

namespace subuxa;

public delegate void CallBack();
public class Player : Animacao
{
    public Player(CachedImageView a) : base(a)
    {
        for (int i = 1; i <= 8; ++i)
            Animacao1.Add($"andar{i.ToString("D2")}.png");
        SetAnimacaoAtiva(1);
    }
    public void Die()
    {
        Loop = false;
        SetAnimacaoAtiva(2);
    }
    public void Run()
    {
        Loop = true;
        SetAnimacaoAtiva(1);
        Play();
    }

    public void MoveY(int n)
    {
        CompImagem.TranslationY += n;
    }

    public double GetY()
    {
        return CompImagem.TranslationY;
    }

    public void SetY(double n)
    {
        CompImagem.TranslationY = n;
    }
}