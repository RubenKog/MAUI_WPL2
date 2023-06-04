using System;
using System.Collections.Generic;
using System.Data;

public abstract class BaseResult
{ 
    private List<string> errors = new List<string>(); 
    public DataTable DataTable{ get; set; } 
    public bool Succeeded { get; set; } 
    public IEnumerable<string> Errors => errors;

    public void AddError(string error)
    { 
        errors.Add(error); 
    } 
}