using RealState.Domain.Abstractions.Entities;

namespace RealState.Domain.RealState.Properties.Entities;

/// <summary>
/// Entidad de dominio que representa una imagen asociada a una propiedad inmobiliaria.
/// </summary>
public sealed class PropertyImage : AuditEntity
{
    public Guid IdProperty { get; private set; }
    public string File { get; private set; } = default!;
    public bool Enabled { get; private set; }

    /// <summary>
    /// Constructor de la entidad <see cref="PropertyImage"/>.
    /// </summary>
    /// <param name="idProperty">Identificador de la propiedad asociada.</param>
    /// <param name="file">Archivo de la imagen.</param>
    /// <param name="enabled">Indica si la imagen está habilitada inicialmente.</param>
    public PropertyImage(Guid idProperty, string file, bool enabled)
    {
        IdProperty = idProperty;
        File = file;
        Enabled = enabled;
    }

    /// <summary>
    /// Habilita la imagen (visible/activa).
    /// </summary>
    public void Enable() => Enabled = true;

    /// <summary>
    /// Deshabilita la imagen (oculta/inactiva).
    /// </summary>
    public void Disable() => Enabled = false;

    /// <summary>
    /// Actualiza el archivo de la imagen.
    /// </summary>
    public void UpdateFile(string newFile) => File = newFile;
}