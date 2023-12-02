import { Home } from "./components/home/Home";
import { MatryoshkaTictactoe } from "./components/matryoshkaTictactoe/MatryoshkaTictactoe";
import { RegularTictactoe } from "./components/regularTictactoe/RegularTictactoe";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/regular-tic-tac-toe',
    element: <RegularTictactoe />
  },
  {
    path: '/matryoshka-tic-tac-toe',
    element: <MatryoshkaTictactoe />
  }
];

export default AppRoutes;
