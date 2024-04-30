import Navbar from "@/Components/Navbar.tsx";
import {Outlet} from "react-router-dom";
import Footer from "@/Components/Footer.tsx";
import DashboardSidebar from "@/Components/Dashboard/DashboardSidebar.tsx";
import {ToastContainer} from "react-toastify";

const Dashboard = () => {
    return (
        <>
            <Navbar/>
            <ToastContainer/>
            <div className=" flex bg-gray-200 mb-12  justify-evenly max-sm:flex-col">
                <DashboardSidebar/>
                <Outlet/>
            </div>

            <Footer/>
        </>
    );
};

export default Dashboard;
