import Navbar from "@/Components/Navbar.tsx";
import {Outlet} from "react-router-dom";
import Footer from "@/Components/Footer.tsx";
import DashboardSidebar from "@/Components/Dashboard/DashboardSidebar.tsx";

const Dashboard = () => {
    return (
        <>
            <Navbar/>
            <div className=" flex  justify-evenly max-sm:flex-col">
                <DashboardSidebar/>
                <Outlet/>
            </div>

            <Footer/>
        </>
    );
};

export default Dashboard;
