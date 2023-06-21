import axios from "axios";
import { useEffect, useState } from "react";
import Header from "./Header";
import SideBar from "./SideBar";
import { Link } from "react-router-dom";
import { BASE_URL } from "../constants";

function Donors(){
    const [Donors,setDonors]=useState([])

    const handleDelete=id=>{
        axios.delete(BASE_URL+"donor/deletedonor?id="+id)
        .then(resp=>loadData());
    }

    const loadData=()=>{
        axios.get(BASE_URL+"donor/getdonor")
        .then(resp=>{
            setDonors(resp.data)
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
                    <Link to="/adddonor" className="btn btn-primary btn-sm mt-2 float-right">Add Donor</Link>
                    <h4 className="text-left p-2 border-bottom border-success">All Donors</h4>
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
                {Donors.map(x=>(
                    <tr key={x.donorId}>
                        <td>{x.donorId}</td>
                        <td>{x.donorName}</td>
                        <td>{x.gender}</td>
                        <td>{x.age}</td>
                        <td>{x.bloodGroup}</td>
                        <td>{x.contactNumber}</td>
                        <td><button className="btn btn-danger btn-sm" onClick={e=>handleDelete(x.donorId)}>Delete</button></td>
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

export default Donors;