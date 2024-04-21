import {Routes, Route} from "react-router-dom";
import HomePage from "./pages/HomePage";
import FoodPage from "./pages/FoodPage";

export default function AppRoutes() {
    return (
        <Routes>
            <Route path="/" element={<HomePage/>}/>
            <Route path="/search/:searchTerm" element={<HomePage/>}/>
            <Route path="/tag/:tagName" element={<HomePage/>}/>
            <Route path="/food/:foodId" element={<FoodPage/>}/>
        </Routes>
    )
}
