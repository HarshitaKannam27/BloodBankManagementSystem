import axios from "axios";
import { useEffect, useState } from "react";
import Header from "./Header";
import SideBar from "./SideBar";
import { Link } from "react-router-dom";
import { BASE_URL } from "../constants";

function Recipients(){
    const [Recipients,setRecipients]=useState([])

    const handleDelete=id=>{
        axios.delete(BASE_URL+"recipient/deleterecipient?id="+id)
        .then(resp=>loadData());
    }

    const loadData=()=>{
        axios.get(BASE_URL+"recipient/getrecipients")
        .then(resp=>{
            setRecipients(resp.data)
        })
    }

    useEffect(()=>{
        loadData()
    },[])
    return(
        <>
        <Header/>
        <div className="container-fluid">
            <div className="row">
                <div className="col-sm-2 bg-transparent p-0 border-right border-primary" style={{height:"calc(100vh - 80px)"}}>
                    <SideBar />
                </div>
                <div className="col-sm-10">
                    <Link to="/addrecipient" className="btn btn-primary btn-sm mt-2 float-right">Add Recipient</Link>
                    <h4 className="text-left p-2 border-bottom border-success">All Recipients</h4>
                    <table className="table table-bordered table-light table-striped table-hover">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Gender</th>
                        <th>Age</th>
                        <th>Blood Group</th>
                        <th>Phone</th>
                        <th>Action</th>                        
                    </tr>
                </thead>
                <tbody>
                {Recipients.map(x=>(
                    <tr key={x.recipientId}>
                        <td>{x.recipientId}</td>
                        <td>{x.recipientName}</td>
                        <td>{x.gender}</td>
                        <td>{x.age}</td>
                        <td>{x.bloodGroup}</td>
                        <td>{x.contactNumber}</td>
                        <td><button className="btn btn-danger btn-sm" onClick={e=>handleDelete(x.recipientId)}>Delete</button></td>
                    </tr>
                ))}
                </tbody>
            </table>
                </div>
            </div>
        </div>
        </>
    )
}

export default Recipients;