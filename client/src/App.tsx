import { BrowserRouter, Outlet, Route, Routes } from "react-router-dom"
import Navbar from "./Components/Navbar"
import Footer from "./Components/Footer"
import RouteTester from "./Pages/RouteTester"
function App() {


  return (
    <>
      <Navbar/>
     <Outlet/>
     <Footer/>

    </>
  )
}

export default App
