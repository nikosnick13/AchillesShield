import { useEffect } from "react";
import { useAuth } from "../context/AuthContext";

function Dashboard() {
    const { user, logout } = useAuth(); 

    useEffect(() => {
        // simple sanity check when Dashboard mounts
        console.log("Dashboard mounted", user);
    }, [user]);

    return (
        <div>
            <h1>Dashboard</h1>
            <p>Welcome, {user?.username ?? "guest"}.</p>
            <button onClick={logout}>Logout</button>
        </div>
    );
}

export default Dashboard;
