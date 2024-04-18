import Navbar from "@/Components/Navbar.tsx";
import {Outlet} from "react-router-dom";
import Footer from "@/Components/Footer.tsx";

const Dashboard = () => {
    return (
        <Navbar/>
        <Outlet/>
        <Footer/>
    );
};

export default Dashboard;
