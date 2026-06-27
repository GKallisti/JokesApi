var  builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var jokes = new List<Joke>
{
    new Joke { Id = 1, Text = "What do you call a fake noodle? An impasta." },
    new Joke { Id = 2, Text = "Why did the scarecrow win an award? Because he was outstanding in his field!" },
    new Joke { Id = 3, Text = "Why did the bicycle fall over? Because it was two-tired!" },
    new Joke { Id = 4, Text = "Why did the math book look sad? Because it had too many problems." },
    new Joke { Id = 5, Text = "Why did the tomato turn red? Because it saw the salad dressing!" }
    new Joke { Id = 6, Text = "Why did the coffee break up with the cream? Because it was too milky!" }
};

app.MapGet("/jokes/random", () =>
{
    var random = new Random();
    int index = random.Next(jokes.Count);
    return jokes[index];
});

app.MapGet("/", () => "Welcome this cursed API! Use the /joke endpoint to get a random joke.");

app.MapPost("/jokes", (Joke newJoke) =>
{   newJoke.Id= jokes.Max(j => j.Id) + 1;
    jokes.Add(newJoke);
    return Results.Created($"/jokes/{newJoke.Id}", newJoke);

});

app.MapGet("/jokes", () => jokes);

app.Run();

public class Joke
{
    public int Id { get; set; }
    public string Text { get; set; }
}