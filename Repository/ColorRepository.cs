using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using dotnettest.Context;
using Microsoft.EntityFrameworkCore;

namespace dotnettest.Repository
{
    public class ColorRepository:IColorRepository
    {
         private ColorContext context;        
 
    public ColorRepository(ColorContext context)        
    {            
        this.context = context;        
    }  
      public List<Color> GetColors()        
    {            
        return context.Colors.ToList();        
    }   

public Color GetColorById(int colorId)        
    {
        return context.Colors.Find(colorId);
    }

 public void InsertColor(Color color)
    {            
        context.Colors.Add(color);      
    }     
    public void DeleteColor(int colorId){
           Color color = this.GetColorById(colorId);              
        context.Colors.Remove(color); 
    }

    public void UpdateColor(Color color){
          context.Entry(color).State = EntityState.Modified;  
    }



    public void Save() {
        try{
        context.SaveChanges();
        }catch(Exception e){
                throw new ArgumentException(e.Message);
        }
    }

        public List<Color> Find(Expression<Func<Color, bool>> predicate)
        {
            return context.Colors.Where(predicate).ToList();
        }
    }
}