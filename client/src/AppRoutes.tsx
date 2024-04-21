import {Routes, Route} from "react-router-dom";
import HomePage from "./pages/HomePage";

export default function AppRoutes() {
    return (
        <Routes>
            <Route path="/" element={<HomePage/>}/>
            <Route path="/search/:searchTerm" element={<HomePage/>}/>
        </Routes>
    )
}
