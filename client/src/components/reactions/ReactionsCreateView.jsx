import { useState } from "react";
import "./ReactionsCreateView.css";

export const ReactionsCreateView = () => {
  const [reactions, setReactions] = useState("");

  const handleSave = (e) => {
    e.preventDefault();
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
