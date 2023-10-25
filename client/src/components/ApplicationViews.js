import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import Players from "./players/Players";
import Games from "./games/Games";
import PlayerDetails from "./players/PlayerDetails";
import { useState } from "react";
import PlayerPage from "./players/PlayerPage";
import PdfViewer from "./Rules";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  const [PlayerDetailsKey, setPlayerDetailsKey] = useState(0);
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <div className="two-column-layout">
                <PdfViewer />
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
          path="games"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Games />
            </AuthorizedRoute>
          }
        />
        <Route
          path="players/:id" 
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <PlayerPage />
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
