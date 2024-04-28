import types from "./notFound.module.css";
import { Link } from "react-router-dom";

export default function NotFound({
  message = "Nothing Found!",
  linkRoute = "/",
  linkText = "Go To Home Page",
}) {
  return (
    <div className={types.container}>
      {message}
      <Link to={linkRoute}>{linkText}</Link>
    </div>
  );
}
