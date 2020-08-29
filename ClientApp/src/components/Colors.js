import React, { Component, useState, useEffect } from 'react';
import axios from "axios"
const Colors = () => {

  const [data, setData] = useState([])
  const [filter,setFilter]=useState(null)
  useEffect(() => {
    axios.get("https://localhost:5001/api/Color/GetColors").then((res) => {
      setData(res.data.result.reverse())
    }).catch((err) => {
      console.error(err)
    })
  }, [])
  const getRandomColor = () => {
    var letters = '0123456789ABCDEF';
    var color = '#';
    for (var i = 0; i < 6; i++) {
      color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
  }
  const addColor = () => {
    debugger
    axios.post("https://localhost:5001/api/Color/AddColor", { name: getRandomColor() }).then((res) => {
      setData([res.data.result, ...data])
    }).catch((err) => {
      console.log(err)
    })
  }

  const deleteColor = (item) => {
    axios.delete("https://localhost:5001/api/Color/DeleteColor/" + item.id).then((res) => {
      let removedData = data.filter((colorItem) => colorItem.id !== item.id)
      setData(removedData)
    }).catch((err) => {
      console.error(err)
    })
  }
  const renderColors = () => {
    if (data && data.length > 0) {
      return data.map((item) => <div key={item.id}
        style={{
          backgroundColor: item.name, height: "40px",
          marginTop: "10px",
          borderRadius: "4px", boxShadow: "0 3px 6px rgba(0,0,0,0.16), 0 3px 6px rgba(0,0,0,0.23)", border: "1px solid #ddd", cursor: "pointer",
          marginBottom: "10px", display: "flex", justifyContent: "center", alignItems: "center", width: "100%"
        }}>
        <p
          onClick={() => {
            deleteColor(item)
          }}>Sil</p>

      </div>)
    }
  }

  const renderFilter=(text)=>{
        setFilter(text)
        debugger
        axios.post("https://localhost:5001/api/Color/findFilterColor", { name: text }).then((res)=>{
          setData(res.data.result)
        }).catch((err)=>{
          debugger
        })

  }

  return (
    <div style={{ display: "flex", flexDirection: "column" }}>
      <input type="text" onChange={(e)=>{
          renderFilter(e.target.value)
      }}  style={{ marginBottom: "20px", height: "40px", padding: "20px", outline: "none", border: "1px solid #ddd", borderRadius: "4px" }} />
      <button onClick={() => { addColor() }}>Tıkla</button>
      {renderColors()}
    </div>
  )
}

export default Colors