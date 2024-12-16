import { toast } from "react-toastify";
import { useAuth } from "../../hooks/useAuth";
import useCart from "../../hooks/useCart";
// import styles from "./header.module.css";
import { Link } from "react-router-dom";

export default function Header() {
  const { user, logout } = useAuth();
  const { totalQuantity } = useCart();

  const handleLogout = () => {
    logout();
    toast.success("Logout successful");
  };
  return (
    <header className="bg-white p-0 border-b border-red-600">
      <div className="mx-auto flex justify-between">
        <Link
          to="/"
          className="font-bold p-4 text-red-500 hover:bg-red-600 hover:text-white "
        >
          Food Order!
        </Link>
        <nav>
          <ul className="flex list-none m-0">
            {user ? (
              <li className="group relative">
                <Link
                  to="/profile"
                  className="block text-red-500 p-4 hover:bg-red-600 hover:text-white cursor-pointer"
                >
                  {user.userName}
                </Link>
                <div className="absolute z-[1001] bg-gray-100 min-w-[8rem] hidden group-hover:block">
                  <Link
                    to="profile"
                    className="block p-4 text-red-500 hover:bg-red-600 hover:text-white"
                  >
                    Profile
                  </Link>
                  <Link
                    to="orders"
                    className="block p-4 text-red-500 hover:bg-red-600 hover:text-white"
                  >
                    Orders
                  </Link>
                  <a
                    onClick={handleLogout}
                    className="block p-4 text-red-500 hover:bg-red-600 hover:text-white cursor-pointer"
                  >
                    Logout
                  </a>
                </div>
              </li>
            ) : (
              <Link
                to="login"
                className="block text-red-500 p-4 hover:bg-red-600 hover:text-white cursor-pointer"
              >
                Login
              </Link>
            )}
            <li>
              <Link
                to="cart"
                className="flex text-red-500 p-4 hover:bg-red-600 hover:text-white cursor-pointer"
              >
                Cart{" "}
                {totalQuantity === 0 && (
                  <span className="ml-1 bg-orange-500 text-white py-1 px-2 rounded-full text-sm">
                    {totalQuantity}
                  </span>
                )}
              </Link>
            </li>
          </ul>
        </nav>
      </div>
    </header>
  );
}
