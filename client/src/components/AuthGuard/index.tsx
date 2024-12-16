import { Navigate, Outlet, useLocation } from "react-router-dom";
import { useAuth } from "../../hooks/useAuth";

type ProtectedRouteProps = { children?: React.ReactElement } & {
  isAllowed: boolean;
  redirectPath?: string;
};

const ProtectedRoute: React.FC<ProtectedRouteProps> = ({
  isAllowed,
  children,
  redirectPath = "/",
}) => {
  const location = useLocation();

  if (!isAllowed) {
    // Redirect them to the /login page, but save the current location they were
    // trying to go to when they were redirected. This allows us to send them
    // along to that page after they login, which is a nicer user experience
    // than dropping them off on the home page.
    return <Navigate to={redirectPath} state={{ from: location }} replace />;
  }
  // Children is used when the ProtectedRoute is not used as Layout component
  return children ?? <Outlet />;
};

type AuthenticationGuardProps = {
  children?: React.ReactElement;
  redirectPath?: string;
  guardType?: "authenticated" | "unauthenticated";
};

const AuthenticationGuard: React.FC<AuthenticationGuardProps> = ({
  redirectPath = "/login",
  guardType = "authenticated",
  ...props
}) => {
  const { user } = useAuth();
  const isAllowed = guardType === "authenticated" ? !!user : !user;

  return (
    <ProtectedRoute
      redirectPath={redirectPath}
      isAllowed={isAllowed}
      {...props}
    />
  );
};

export default AuthenticationGuard;
