import axios from "axios";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import Header from "./Header";
import SideBar from "./SideBar";
import { BASE_URL } from "../constants";

function RegisterPage() {
  const [banks, setbanks] = useState([]);
  const [donor, setdonor] = useState({
    donorName: "",
    bloodGroup: "",
    age: 0,
    gender: "",
    contactNumber: "",
    bloodBankId: 0,
  });
  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();

    axios
      .post(BASE_URL+"donor/adddonor", donor)
      .then((resp) => {
        e.target.reset();
        alert("Donor registered successfully");
        navigate("/donors")
      })
      .catch((error) => console.log("Error", error));
  };

  useEffect(() => {
    axios
      .get(BASE_URL+"BloodBankCenter/GetAllBloodBankCenters")
      .then((resp) => {
        setbanks(resp.data);
      });
  }, []);
  return (
    <>
    <Header/>
        <div className="container-fluid">
            <div className="row">
                <div className="col-sm-2 bg-transparent p-0 border-right border-primary" style={{height:"calc(100vh - 80px)"}}>
                    <SideBar />
                </div>
                <div className="col-sm-10">
        <div className="card shadow pt-3">
          <div className="card-body">
            <h5 className="text-center p-2">Donor Registration</h5>
            <form onSubmit={handleSubmit}>
              <div className="row">
                <div className="col-sm-6 offset-1">
                  <div className="form-group form-row">
                    <label className="col-sm-4 form-control-label">
                      Donor Name
                    </label>
                    <div className="col-sm-8">
                      <input
                        type="text"
                        name="name"
                        required
                        value={donor?.donorName}
                        onChange={e=>setdonor({...donor,donorName:e.target.value})}
                        className="form-control"
                      />
                    </div>
                  </div>
                  <div className="form-group form-row">
                    <label className="col-sm-4 form-control-label">
                      Blood Group
                    </label>
                    <div className="col-sm-8">
                      <input
                        type="text"
                        required
                        name="address"
                        value={donor?.bloodGroup}
                        onChange={e=>setdonor({...donor,bloodGroup:e.target.value})}
                        className="form-control"
                      />
                    </div>
                  </div>
                  <div className="form-group form-row">
                    <label className="col-sm-4 form-control-label">
                      Gender
                    </label>
                    <div className="col-sm-8">
                      <select
                        name="gender"
                        required
                        value={donor?.gender}
                        onChange={e=>setdonor({...donor,gender:e.target.value})}
                        className="form-control"
                      >
                        <option value="">Select Gender</option>
                        <option>Male</option>
                        <option>Female</option>
                      </select>
                    </div>
                  </div>
                  
                  <div className="form-group form-row">
                    <label className="col-sm-4 form-control-label">
                     Age
                    </label>
                    <div className="col-sm-8">
                      <input
                        type="number"
                        min="10"
                        name="age"
                        value={donor?.age}
                        onChange={e=>setdonor({...donor,age:e.target.value})}
                        className="form-control"
                      />
                    </div>
                  </div>
                  <div className="form-group form-row">
                    <label className="col-sm-4 form-control-label">Phone</label>
                    <div className="col-sm-8">
                      <input
                        type="text"
                        maxLength="10"
                        name="phone"
                        required
                        value={donor?.contactNumber}
                        onChange={e=>setdonor({...donor,contactNumber:e.target.value})}
                        className="form-control"
                      />
                    </div>
                  </div>
                  <div className="form-group form-row">
                    <label className="col-sm-4 form-control-label">
                      Blood Bank
                    </label>
                    <div className="col-sm-8">
                      <select
                        name="bloodBankId"
                        required
                        value={donor?.bloodBankId}
                        onChange={e=>setdonor({...donor,bloodBankId:e.target.value})}
                        className="form-control"
                      >
                        <option value="">Select Bank</option>
                        {banks.map(x=>(
                            <option value={x.bloodBankId}>{x.centerName}-{x.location}</option>
                        ))}
                      </select>
                    </div>
                  </div>

                  <button className="btn btn-primary float-right">
                    Register Donor
                  </button>
                </div>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
    </div>
    </>
  );
}

export default RegisterPage;
