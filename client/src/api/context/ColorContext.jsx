import { createContext, useEffect, useState } from "react";
import ColorService from "../services/ColorService";

const ColorContext = createContext()

export const ColorProvider=({children})=>{

    const [colors,setColors]=useState([])
    const colorService = new ColorService()
    const getData=async()=>{
        try {
            let result = await colorService.getColors()
            setColors(result.data.data)
        } catch (error) {
            console.log(error)
        }
    }
    useEffect(()=>{
        getData()
    },[])

    const values ={
        colors,
        setColors
    }

    return <ColorContext.Provider value={values}>{children}</ColorContext.Provider>
}

export default ColorContext