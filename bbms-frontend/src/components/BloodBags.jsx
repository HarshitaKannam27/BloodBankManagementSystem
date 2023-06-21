import axios from "axios";
import { useEffect, useState } from "react";
import Header from "./Header";
import SideBar from "./SideBar";
import { BASE_URL } from "../constants";

function BloodBags() {
  const [BloodBags, setBloodBags] = useState([]);
  const [banks, setbanks] = useState([]);
  const [donors,setdonors]=useState([])
  const [bloodbag,setbloodbag]=useState({
    bloodGroup:"",
    quantity:"",
    donorId:"",
    bloodBankId:""
  })

  const handleSubmit=e=>{
    axios.post(BASE_URL+"BloodBag/AddBloodBag",bloodbag)
    .then(resp=>{
        loadData()
    })
  }

  const handleDelete=id=>{
    axios.delete(BASE_URL+"BloodBag/DeleteBloodBag?id="+id)
    .then(resp=>{
        loadData();
    })
  }

  const loadData=()=>{
    axios
      .get(BASE_URL+"BloodBag/GetBloodBag")
      .then((resp) => {
        setBloodBags(resp.data);
      });
  }

  useEffect(() => {
    loadData()
    axios
    .get(BASE_URL+"BloodBankCenter/GetAllBloodBankCenters")
    .then((resp) => {
      setbanks(resp.data);
    });
    axios.get(BASE_URL+"donor/getdonor")
        .then(resp=>{
            setdonors(resp.data)
        })
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
              Blood Bags
            </h4>
            <table className="table table-bordered table-light table-sm table-striped table-hover">
              <thead>
                <tr>
                  <th>Id</th>
                  <th>Blood Group</th>
                  <th>Quantity</th>
                  <th>Donor</th>
                  <th>Blood Bank</th>
                  <th>Action</th>
                </tr>
              </thead>
              <tbody>
                {BloodBags.map((x) => (
                  <tr key={x.bagId}>
                    <td>{x.bagId}</td>
                    <td>{x.bloodGroup}</td>
                    <td>{x.quantity} ml</td>
                    <td>{x.donor.donorName}</td>
                    <td>{x.bloodBankCenter.centerName} {x.bloodBankCenter.location}</td>
                    <td><button className="btn btn-danger btn-sm" onClick={e=>handleDelete(x.bagId)}>Delete</button></td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
          <div className="col-sm-3">
            <h5 className="p-2">Add Blood Bag</h5>
            <form onSubmit={handleSubmit}>
                <div className="form-group">
                    <label>Blood Group</label>
                    <input type="text" name="centerName" value={bloodbag?.bloodGroup} onChange={e=>setbloodbag({...bloodbag,bloodGroup:e.target.value})} className="form-control" />
                </div>
                <div className="form-group">
                    <label>Quantity (in ml)</label>
                    <input type="number" name="quantity" value={bloodbag?.quantity} onChange={e=>setbloodbag({...bloodbag,quantity:e.target.value})} className="form-control" />
                </div>
                <div className="form-group">
                    <label>Donor</label>
                    <select name="donorId" value={bloodbag?.donorId} onChange={e=>setbloodbag({...bloodbag,donorId:e.target.value})} className="form-control">
                      <option>Select Donor</option>
                      {donors.map(x=>(
                            <option value={x.donorId}>{x.donorName} {x.bloodGroup}</option>
                        ))}
                    </select>
                </div>
                <div className="form-group">
                    <label>Blood Bank</label>
                    <select
                        name="bloodBankId"
                        value={bloodbag?.bloodBankId}
                        onChange={e=>setbloodbag({...bloodbag,bloodBankId:e.target.value})}
                        className="form-control"
                      >
                        <option value="">Select Bank</option>
                        {banks.map(x=>(
                            <option value={x.bloodBankId}>{x.centerName}-{x.location}</option>
                        ))}
                      </select>
                </div>
                <button type="submit" className="btn btn-primary">Save</button>
            </form>
          </div>
        </div>
      </div>
    </>
  );
}

export default BloodBags;
