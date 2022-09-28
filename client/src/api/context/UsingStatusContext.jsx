import { createContext, useEffect, useState } from "react";
import UsingStatusService from "../services/UsingStatusService";

const UsingStatusContext = createContext()
 
export const UsingStatusProvider=({children})=>{

    const [usingStatuses,setUsingStatuses]= useState([])
    const usingStatusService = new UsingStatusService();
    const getData=async()=>{
        try {
            let result = await usingStatusService.getUsingStatus()
            setUsingStatuses(result.data.data)
        } catch (error) {
            console.log(error)
        }
    }

    useEffect(()=>{
        getData()
    },[])

    const values ={
        usingStatuses,
        setUsingStatuses
    }


    return <UsingStatusContext.Provider value={values}>{children}</UsingStatusContext.Provider>
}

export default UsingStatusContext