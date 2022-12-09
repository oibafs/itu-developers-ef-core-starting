namespace Sample.Data.Entities;

public sealed class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Country { get; set; } = default!;
    public string Bio { get; set; } = default!;
}
