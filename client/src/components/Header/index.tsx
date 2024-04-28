import useCart from "../../hooks/useCart";
import styles from "./header.module.css";
import { Link } from "react-router-dom";

export default function Header() {
  const user = {
    name: "John Doe",
  };

  const { totalQuantity } = useCart();

  const logout = () => {};

  return (
    <header className={styles.header}>
      <div className={styles.container}>
        <Link to="/" className={styles.logo}>
          Food Order!
        </Link>
        <nav>
          <ul>
            {user ? (
              <li className={styles.menu_container}>
                <Link to="/profile">{user.name}</Link>
                <div className={styles.menu}>
                  <Link to="profile">Profile</Link>
                  <Link to="orders">Orders</Link>
                  <a onClick={logout}>Logout</a>
                </div>
              </li>
            ) : (
              <Link to="login">Login</Link>
            )}
            <li>
              <Link to="cart">
                Cart{" "}
                {totalQuantity > 0 && (
                  <span className={styles.cart_count}>{totalQuantity}</span>
                )}
              </Link>
            </li>
          </ul>
        </nav>
      </div>
    </header>
  );
}
