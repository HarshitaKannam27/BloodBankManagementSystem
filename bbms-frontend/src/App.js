import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import LoginPage from './components/LoginPage';
import RegisterPage from './components/AddDonor';
import Dashboard from './components/Dashboard';
import Donors from './components/Donors';
import BloodBanks from './components/BloodBanks';
import BloodBags from './components/BloodBags';
import Recipients from './components/Recipients';
import AddRecipient from './components/AddRecipient';

function App() {
  return (
    <div className="App">
      <BrowserRouter>      
        <Routes>
          <Route element={<LoginPage />} path="/" exact />                    
          <Route element={<LoginPage />} path="/login" />                    
          <Route element={<RegisterPage/>} path="/adddonor"/>                                                         
          <Route element={<AddRecipient/>} path="/addrecipient"/>                                                         
          <Route element={<Dashboard/>} path="/dashboard"/>                              
          <Route element={<Donors/>} path="/donors"/>                              
          <Route element={<Recipients/>} path="/recipients"/>                              
          <Route element={<BloodBanks/>} path="/bloodbanks"/>                              
          <Route element={<BloodBags/>} path="/bloodbags"/>                              
                              
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
