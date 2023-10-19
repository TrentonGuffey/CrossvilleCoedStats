import { useState } from "react";
import GameTable from "./GamesTable";

export default function Games() {
    const [detailsGameId, setDetailsGameId] = useState(null)

    return (
        <div className="container">
            <div className="row">
                <div className="col-sm-4">
                    <GameTable setDetailsGameId={setDetailsGameId} />
                </div>
            </div>
        </div>
    );
}