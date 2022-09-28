import { createContext, useEffect, useState } from "react";
import jwtDecode from 'jwt-decode';
import {useNavigate} from "react-router-dom";

const AuthContext = createContext()

export const AuthProvider = ({ children }) => {

    const [auth, setAuth] = useState(false)
    const [user, setUser] = useState({ userId: 0, userName: "" })
    const token = localStorage.getItem("token")
    const navigate = useNavigate()

    const checkTokenExprired = async () => {
        if (token) {
            let decode = await jwtDecode(token)
            let currentDate = new Date();
            if (decode.exp * 1000 < currentDate.getTime()) {
                localStorage.removeItem("token")
                console.log("Token Exprired")
                setAuth(false)
                navigate("/")
            }
        }
    }
    const isLogged = async () => {
        try {
            if (token) {
                let decode = await jwtDecode(token)
                setUser({
                    userId: decode["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"],
                    userName: decode["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"]
                })
                setAuth(true)
            } else {
                setUser({userId:0,userName:""})
                setAuth(false)
            }
        } catch (error) {
            setAuth(false)
            localStorage.removeItem("token")
        }
    }
    useEffect(() => {
        isLogged()
        checkTokenExprired()
    }, [auth])

    const values = {
        auth,
        setAuth,
        setUser,
        user
    }
    return <AuthContext.Provider value={values}>{children}</AuthContext.Provider>
}

export default AuthContext