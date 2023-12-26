using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Football;

public partial class Team
{
    public int Id { get; set; }

    [Display(Name = "Команда")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    public string TeamName { get; set; } = null!;

    [Display(Name = "Місто")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    public string TeamCity { get; set; } = null!;

    [Display(Name = "Стадіон")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    public string StadiumName { get; set; } = null!;

    [Display(Name = "Власник")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    public string OwnerName { get; set; } = null!;

    [Display(Name = "Лого")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    public string TeamLogo { get; set; } = null!;

    [Display(Name = "Ліга")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    public int LeagueId { get; set; }
    public virtual League League { get; set; } = null!;

}
