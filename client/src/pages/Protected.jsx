import React from 'react'
import { Button, Stack } from 'react-bootstrap'
import {Link} from 'react-router-dom'

function Protected() {
  return (
    <div>
       <h1 className="mt-3 text-center">You need to Login for this operation</h1>
       <hr />
       <Stack  className="col-md-6 mx-auto" direction='horizantal' gap={3}>
        <Button as={Link} to="/login">Log in</Button>
        <Button as={Link} to="/register" variant='success'>Register</Button>
       </Stack>
    </div>
  )
}

export default Protected