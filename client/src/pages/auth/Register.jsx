import axios from 'axios';
import { useFormik } from 'formik';
import React, { useContext } from 'react'
import { useState } from 'react';
import { Button, Stack, Alert, Spinner } from 'react-bootstrap';
import Form from 'react-bootstrap/Form';
import { useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
import AuthContext from '../../api/context/AuthContext';
import AuthService from '../../api/services/AuthService';
import registerSchema from '../../validations/RegisterValidation';

function Register() {
    const navigate = useNavigate()
    const authService = new AuthService()
    const { setAuth } = useContext(AuthContext)
    const [isLoading, setIsLoading] = useState(false)

    const handleSendEmail = async (email) => {
        toast("Email Sending..", {
            position: 'bottom-right'
        })
        try {
            const result = await authService.sendWelcomeEmail(email)
            if (result.data.success) {
                toast.success("Email Sended !", {
                    position: 'bottom-right'
                })
            } else {
                toast.error("Email Not Sended", {
                    position: 'bottom-right'
                })
            }
        } catch (error) {
            console.log(error)
            toast.error("Email Not Sended",{
                position:'bottom-right'
            })
        }
    }
    const formik = useFormik({
        initialValues: {
            firstName: "",
            lastName: "",
            email: "",
            password: ""
        },
        onSubmit: async (values) => {
            setIsLoading(true)
            try {
                const response = await authService.register(values)
                setIsLoading(false)
                const token = await response.data.token
                if (token) {
                    localStorage.setItem("token", token);
                    setAuth(true)
                    toast.success("Successfully Registered !", {
                        position: 'bottom-right'
                    })
                    navigate("/")
                    handleSendEmail(values.email)
                } else {
                    setAuth(false)
                    toast.error("Error", {
                        position: 'top-right'
                    })
                }
            } catch (error) {
                toast.error(error.response.data, {
                    position: 'top-right'
                })
            }
        },
        validationSchema: registerSchema
    })
    return (
        <div>
            <form onSubmit={formik.handleSubmit}>
                <h1 className="text-center">Register</h1>
                <Stack gap={2} className="col-md-6 mx-auto">
                    <Form.Label>First Name</Form.Label>
                    <Form.Control
                        placeholder='First Name'
                        name='firstName'
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.firstName}
                    />
                    {formik.errors.firstName && formik.touched.firstName && <Alert variant='danger'>{formik.errors.firstName}</Alert>}
                    <br />
                    <Form.Label>Last Name</Form.Label>
                    <Form.Control
                        placeholder='Last Name'
                        name='lastName'
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.lastName}
                    />
                    {formik.errors.lastName && formik.touched.lastName && <Alert variant='danger'>{formik.errors.lastName}</Alert>}
                    <br />
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
                    {formik.errors.email && formik.touched.email && <Alert variant='danger'>{formik.errors.email}</Alert>}
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
                    {formik.errors.password && formik.touched.password && <Alert variant='danger'>{formik.errors.password}</Alert>}
                    <br />
                    <Button variant='success' type='submit'>{isLoading ? <Spinner animation="border" /> : "Register"}</Button>
                </Stack>


            </form>

        </div>
    )
}

export default Register