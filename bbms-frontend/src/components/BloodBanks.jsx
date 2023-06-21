import axios from "axios";
import { useEffect, useState } from "react";
import Header from "./Header";
import SideBar from "./SideBar";
import { BASE_URL } from "../constants";

function BloodBanks() {
  const [BloodBanks, setBloodBanks] = useState([]);
  const [bloodbank,setbloodbank]=useState({
    centerName:"",
    location:""
  })

  const handleSubmit=e=>{
    axios.post(BASE_URL+"BloodBankCenter/AddBloodBankCenter",bloodbank)
    .then(resp=>{
        loadData()
    })
  }

  const handleDelete=id=>{
    axios.delete(BASE_URL+"BloodBankCenter/DeleteBloodBankCenter?id="+id)
    .then(resp=>{
        loadData();
    })
  }

  const loadData=()=>{
    axios
      .get(BASE_URL+"BloodBankCenter/GetAllBloodBankCenters")
      .then((resp) => {
        setBloodBanks(resp.data);
      });
  }

  useEffect(() => {
    loadData()
  }, []);
  return (
    <>
      <Header />
      <div className="container-fluid">
        <div className="row">
          <div
            className="col-sm-2 bg-transparent p-0 border-right border-primary"
            style={{ height: "calc(100vh - 80px)" }}
          >
            <SideBar />
          </div>
          <div className="col-sm-7">
            <h4 className="text-left p-2 border-bottom border-success">
              Blood Bank Centers
            </h4>
            <table className="table table-bordered table-light table-sm table-striped table-hover">
              <thead>
                <tr>
                  <th>Id</th>
                  <th>Center Name</th>
                  <th>Location</th>
                  <th>Action</th>
                </tr>
              </thead>
              <tbody>
                {BloodBanks.map((x) => (
                  <tr key={x.bloodBankId}>
                    <td>{x.bloodBankId}</td>
                    <td>{x.centerName}</td>
                    <td>{x.location}</td>
                    <td><button className="btn btn-danger btn-sm" onClick={e=>handleDelete(x.bloodBankId)}>Delete</button></td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
          <div className="col-sm-3">
            <h5 className="p-2">Add Blood Bank Center</h5>
            <form onSubmit={handleSubmit}>
                <div className="form-group">
                    <label>Center Name</label>
                    <input type="text" name="centerName" value={bloodbank?.centerName} onChange={e=>setbloodbank({...bloodbank,centerName:e.target.value})} className="form-control" />
                </div>
                <div className="form-group">
                    <label>Location</label>
                    <input type="text" name="location" value={bloodbank?.location} onChange={e=>setbloodbank({...bloodbank,location:e.target.value})} className="form-control" />
                </div>
                <button type="submit" className="btn btn-primary">Save</button>
            </form>
          </div>
        </div>
      </div>
    </>
  );
}

export default BloodBanks;
