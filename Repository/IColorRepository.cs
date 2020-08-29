using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace dotnettest.Repository
{
    public interface IColorRepository
    {
    List<Color> GetColors();        
    Color GetColorById(int customerId);        
     List<Color> Find(Expression<Func<Color,bool>> predicate);
    void InsertColor(Color color);        
    void DeleteColor(int colorId);        
    void UpdateColor(Color color);        
    void Save(); 
    }
}
