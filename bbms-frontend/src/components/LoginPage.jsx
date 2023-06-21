import axios from "axios";
import { useState } from "react"
import { useNavigate } from "react-router-dom";
import { BASE_URL } from "../constants";


function LoginPage(){
    const navigate=useNavigate()
    const [errmsg,setErrmsg]=useState(null)

    const [user,setUser]=useState({
        "username":"",
        "password":""
    })

    const handleInput=(e)=>{
        setUser({...user,[e.target.name]:e.target.value})
    }

    const handleSubmit=e=>{
        e.preventDefault()  
            axios.post(BASE_URL+"user/login",user)
            .then(resp=>{
                let result=resp.data;
                console.log(resp.data)
                sessionStorage.setItem("uname",result.name)
                sessionStorage.setItem("role",result.role)
                sessionStorage.setItem("id",result.id)  
                if(result.role==='Admin')
                    navigate("/dashboard")
                else
                    navigate("/chome")
            })
            .catch(error=>{
                console.log("Error",error);
                setErrmsg("Invalid username or password");
            })            
    }

    return(
        <div className="login">
            <div className="jumbotron p-4 text-center border-bottom bg-transparent">
                <h4>Blood Bank Management</h4>    
            </div>
            <div className="container">
                <div className="row">
                    <div className="col-sm-5 mx-auto">
                        <form className="card shadow bg-transparent"  onSubmit={handleSubmit}> 
                            <div className="card-header text-center text-white bg-transparent">
                                <h4>Login Screen</h4>
                            </div>                            
                            <div className="card-body">
                                <div className="form-group form-row">
                                    <label className="col-sm-4 col-form-label">User Id</label>
                                    <div className="col-sm-8">
                                    <input type="text" name="username" required className="form-control" placeholder="User Id"  value={user.username} onChange={handleInput}/>
                                    </div>
                                </div>
                                <div className="form-group form-row">
                                    <label className="col-sm-4 col-form-label">Password</label>
                                    <div className="col-sm-8">
                                    <input type="password" required className="form-control" name="password" placeholder="Password" value={user.password} onChange={handleInput} />
                                    </div>
                                </div>
                                <button className="btn btn-primary float-right">Login</button>
                            </div>
                            {errmsg !=null ? (
                                <div className="alert text-danger text-center font-weight-bold">
                                    {errmsg}
                                </div>
                            ): ''}
                        </form>
                    </div>
                </div>

            </div>
        </div>
    )
}

export default LoginPage;