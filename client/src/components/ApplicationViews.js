import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import Players from "./players/Players";
import Games from "./games/Games";
import PlayerDetails from "./players/PlayerDetails";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <div className="two-column-layout">
                <Players />
                <Games /> 
              </div>             
            </AuthorizedRoute>
          }
        />
        <Route
          path="players"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Players />
            </AuthorizedRoute>
          }
        />
        <Route
          path="players/:id" 
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <PlayerDetails />
            </AuthorizedRoute>
          }
        />
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
