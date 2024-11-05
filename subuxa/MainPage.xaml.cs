namespace subuxa;

public partial class MainPage : ContentPage
{
	bool EstaMorto = false;
	bool EstaPulando = false;
	const int TempoEntreFrames = 25;
	 int velocidade1 = 0;
	 int velocidade2 = 0;
	 int velocidade3 = 0;
	 int velocidade4 = 0;
	 int velocidade5 = 0;
	 int velocidade6 = 0;
	 int velocidade7 = 0;
	 int LarguraJanela = 0;
	 int AlturaJanela = 0;
	public MainPage()
	{
		InitializeComponent();
	}
    protected override void OnSizeAllocated(double w, double h)
    {
        base.OnSizeAllocated(w, h);
		CorrigeTamanhoCenario(w, h);
		CalculaVelocidade(w);
    }
	void CalculaVelocidade(double w)
	{
		velocidade1 = (int)(w * 0.001);
		velocidade2 = (int)(w * 0.004);
		velocidade3 = (int)(w * 0.008);
		velocidade4 = (int)(w * 0.012);
		velocidade5 = (int)(w * 0.016);
		velocidade6 = (int)(w * 0.020);
		velocidade7 = (int)(w * 0.01);
	}
	void CorrigeTamanhoCenario(double w, double h)
	{
		foreach (var a in HSLayer1.Children)
		(a as Image).WidthRequest = w;
		foreach (var a in HSLayer2.Children)
		(a as Image).WidthRequest = w;
		foreach (var a in HSLayer3.Children)
	    (a as Image).WidthRequest = w;
		foreach (var a in HSLayer4.Children)
		(a as Image).WidthRequest = w;
		foreach (var a in HSLayer5.Children)
		(a as Image).WidthRequest = w;
		foreach (var a in HSLayer6.Children)
		(a as Image).WidthRequest = w;
		foreach (var a in HSLayer7.Children)
		(a as Image).WidthRequest = w;

		HSLayer1.WidthRequest = w * 1.5;
		HSLayer2.WidthRequest = w * 1.5;
		HSLayer3.WidthRequest = w * 1.5;
		HSLayer4.WidthRequest = w * 1.5;
		HSLayer5.WidthRequest = w * 1.5;
		HSLayer6.WidthRequest = w * 1.5;
		HSLayer7.WidthRequest = w * 1.5;
	}
	void GerenciaCenario()
	{
		MoveCenario();
		GerenciaCenario(HSLayer1);
		GerenciaCenario(HSLayer2);
		GerenciaCenario(HSLayer3);
		GerenciaCenario(HSLayer4);
		GerenciaCenario(HSLayer5);
		GerenciaCenario(HSLayer6);
		GerenciaCenario(HSLayer7);
	}
    void MoveCenario()
	{
		HSLayer1.TranslationX -= velocidade1;
		HSLayer2.TranslationX -= velocidade2;
		HSLayer3.TranslationX -= velocidade3;
		HSLayer4.TranslationX -= velocidade4;
		HSLayer5.TranslationX -= velocidade5;
		HSLayer6.TranslationX -= velocidade6;
		HSLayer7.TranslationX -= velocidade7;
	}
	void GerenciaCenario(HorizontalStackLayout HSL)
	{
		var view = (HSL.Children.First() as Image);
		if (view.WidthRequest + HSL.TranslationX < 0)
		{
			HSL.Children.Remove(view);
			HSL.Children.Add(view);
			HSL.TranslationX = view.TranslationX;
		}
	}
	async Task Desenha()
	{
		while(!EstaMorto)
		{
			GerenciaCenario();
			await Task.Delay(TempoEntreFrames);
		}
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		Desenha();
    }
}