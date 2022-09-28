import { useFormik } from 'formik';
import React, { useContext } from 'react'
import { useState } from 'react';
import { Alert, Button, Stack ,Spinner} from 'react-bootstrap';
import Form from 'react-bootstrap/Form';
import { useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
import AuthContext from '../../api/context/AuthContext';
import AuthService from '../../api/services/AuthService';
import loginSchema from '../../validations/LoginValidation';


function Login() {
    const navigate = useNavigate()
    const authService = new AuthService()
    const { setAuth } = useContext(AuthContext)
    const [isLoading,setIsLoading] = useState(false)
    const formik = useFormik({
        initialValues: {
            email: "",
            password: ""
        },
        onSubmit: async (values) => {
            setIsLoading(true)
            try {
                const response = await authService.login(values)
                const token = await response.data.token
                if (token) {
                    localStorage.setItem("token", token);
                    setAuth(true)
                    setIsLoading(false)
                    toast.success("Successfully Logged in", {
                        position: 'top-center'
                    })
                    navigate("/")
                } else {
                    setAuth(false)
                    toast.error("Auth Error", {
                        position: 'top-right'
                    })
                }
            } catch (error) {
                toast.error(error.response.data, {
                    position: 'top-right'
                })
                setIsLoading(false)
            }
        },
        validationSchema: loginSchema
    })

    return (
        <div>
            <h1 className="mt-3 text-center">Login</h1>
            <form onSubmit={formik.handleSubmit}>
                <Stack gap={2} className="col-md-6 mx-auto">
                    <Form.Label>Email</Form.Label>
                    <Form.Control
                        placeholder='Email'
                        name='email'
                        type='email'
                        autoComplete='off'
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.email}
                       
                    />
                    {formik.errors.email && formik.touched.email  && <Alert variant='danger'>{formik.errors.email}</Alert>}
                    <br />
                    <Form.Label>Password</Form.Label>
                    <Form.Control
                        placeholder='Password'
                        name='password'
                        type='password'
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.password}
                    />
                     {formik.errors.password && formik.touched.password  && <Alert variant='danger'>{formik.errors.password}</Alert>}
                    <br />
                    <Button variant='success' type='submit'>{isLoading ? <Spinner animation="border" /> : "Login"}</Button>
                    <br />
                </Stack>
            </form>
        </div>

    )
}

export default Login