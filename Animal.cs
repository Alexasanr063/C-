using System;
using System.Collections.Generic;

namespace SampleNamespace;
[Serializable]
public class Animal
{
    public string? name ;
    public string? login ;
    public string? delts ;
    public string? age ;

  
  public string[] peoples = new string[3];

   

     public Animal(){

     }

     public Animal(string name, string login, string age, string delts){
       this.name = name;
       this.login = login;
       this.age = age;
       this.delts = delts;
     }
}