import { useState } from "react";
import "./ReactionsCreateView.css";
import { createNewReaction } from "../../managers/reaction";
import { useNavigate } from "react-router-dom";

export const ReactionsCreateView = () => {
  const [reactions, setReactions] = useState("");
  const navigate = useNavigate();

  const handleSave = (e) => {
    e.preventDefault();
    if (reactions != "") {
      createNewReaction({ ImageUrl: reactions });
    }
  };

  return (
    <main>
      <div>
        <section>
          {reactions != "" && (
            <img
              className="ReactionsCreateView-img-viewinput"
              src={reactions}
            />
          )}
        </section>
        <form onSubmit={handleSave}>
          <input
            defaultValue={reactions}
            onChange={(e) => {
              setReactions(e.target.value);
            }}
          />
          <button type="submit">Add</button>
        </form>
      </div>
    </main>
  );
};
