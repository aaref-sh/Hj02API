﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.Core.Models;

public class View
{
    public Guid Id { get; set; }
    public Post Post { get; set; }
    public User User { get; set; }
}
