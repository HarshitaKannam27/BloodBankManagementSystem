import axios from "axios";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import Header from "./Header";
import SideBar from "./SideBar";
import { BASE_URL } from "../constants";

function AddRecipient() {
  const [banks, setbanks] = useState([]);
  const [recipient, setrecipient] = useState({
    recipientName: "",
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
      .post(BASE_URL+"recipient/CreateRecipient", recipient)
      .then((resp) => {
        e.target.reset();
        alert("Recipient registered successfully");
        navigate("/recipients")
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
            <h5 className="text-center p-2">Recipient Registration Form</h5>
            <form onSubmit={handleSubmit}>
              <div className="row">
                <div className="col-sm-6 offset-1">
                  <div className="form-group form-row">
                    <label className="col-sm-4 form-control-label">
                      Recipient Name
                    </label>
                    <div className="col-sm-8">
                      <input
                        type="text"
                        name="name"
                        required
                        value={recipient?.recipientName}
                        onChange={e=>setrecipient({...recipient,recipientName:e.target.value})}
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
                        name="address"
                        required
                        value={recipient?.bloodGroup}
                        onChange={e=>setrecipient({...recipient,bloodGroup:e.target.value})}
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
                        value={recipient?.gender}
                        onChange={e=>setrecipient({...recipient,gender:e.target.value})}
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
                        value={recipient?.age}
                        onChange={e=>setrecipient({...recipient,age:e.target.value})}
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
                        value={recipient?.contactNumber}
                        onChange={e=>setrecipient({...recipient,contactNumber:e.target.value})}
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
                      required
                        name="bloodBankId"
                        value={recipient?.bloodBankId}
                        onChange={e=>setrecipient({...recipient,bloodBankId:e.target.value})}
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
                    Register recipient
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

export default AddRecipient;
