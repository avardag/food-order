import { Link } from "react-router-dom";

export default function NotFound({
  message = "Nothing Found!",
  linkRoute = "/",
  linkText = "Go To Home Page",
}) {
  return (
    <div className="flex flex-col justify-center items-center text-2xl h-60">
      {message}
      <Link
        to={linkRoute}
        className="text-base bg-red-600 text-white opacity-90 m-4 px-4 py-3 rounded-full hover:opacity-100 hover:cursor-pointer"
      >
        {linkText}
      </Link>
    </div>
  );
}
